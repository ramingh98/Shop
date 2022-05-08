﻿using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BookShop.Query.Users.DTOs;
using Microsoft.IdentityModel.Tokens;

namespace BookShop.API.Infrastructures.JwtUtil
{
    public class JwtTokenBuilder
    {
        public static string BuildToken(UserDto user, IConfiguration configuration)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.MobilePhone,user.PhoneNumber),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JwtConfig:SignInKey"]));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: configuration["JwtConfig:Issuer"],
                audience: configuration["JwtConfig:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credential);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}