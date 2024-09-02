using System.ComponentModel.DataAnnotations;
using Swashbuckle.AspNetCore.Annotations;

namespace WebinarEFCQRS.Domain;

public class Entity
{
    [Key] [SwaggerSchema(ReadOnly = true)] public int Id { get; set; }
}