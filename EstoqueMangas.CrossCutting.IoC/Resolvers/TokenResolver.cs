﻿using System;
using System.Globalization;
using EstoqueMangas.Infra.SecurityConfigurations;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.DependencyInjection;

namespace EstoqueMangas.CrossCutting.IoC.Resolvers
{
    public static class TokenResolver
    {
        #region Atributos
        private const string _issuer = "c1f51f42";
        private const string _audience = "c6bbbb645024";
        #endregion
        #region Métodos
        public static IServiceCollection ConfigureToken(this IServiceCollection services)
        {
            //Configuração do Token
            var signingConfigurations = new SigningConfigurations();
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations
            {
                Audience = _audience,
                Issuer = _issuer,
                Seconds = int.Parse(TimeSpan.FromDays(1).TotalSeconds.ToString(CultureInfo.InvariantCulture))

            };

            services.AddSingleton(tokenConfigurations);

            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                    .AddJwtBearer(bearerOptions =>
                    {
                        var paramsValidation = bearerOptions.TokenValidationParameters;
                        paramsValidation.IssuerSigningKey = signingConfigurations.SigningCredentials.Key;
                        paramsValidation.ValidAudience = tokenConfigurations.Audience;
                        paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                        // Valida a assinatura de um token recebido
                        paramsValidation.ValidateIssuerSigningKey = true;

                        // Verifica se um token recebido ainda é válido
                        paramsValidation.ValidateLifetime = true;

                        // Tempo de tolerância para a expiração de um token (utilizado
                        // caso haja problemas de sincronismo de horário entre diferentes
                        // computadores envolvidos no processo de comunicação)
                        paramsValidation.ClockSkew = TimeSpan.Zero;
                    });

            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser().Build());
            });

            return services;
        }
        #endregion
    }
}
