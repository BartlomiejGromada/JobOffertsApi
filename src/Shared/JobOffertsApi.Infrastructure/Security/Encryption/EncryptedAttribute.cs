using System;

namespace JobOffersApi.Infrastructure.Security.Encryption;

[AttributeUsage(AttributeTargets.Property)]
public class EncryptedAttribute : Attribute
{
}