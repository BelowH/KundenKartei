using System;

namespace KundenKartei.Domain.DTO;

public record SearchResult(string id, string label, Type type)
{
    public string Id { get; init; } = id;

    public string Label { get; init; } = label;
    
    public Type Type { get; init; } = type;
};