using ProjectTracker.DTOs;
using ProjectTracker.Entities;

namespace ProjectTracker.Mapping;

public static class LanguageMapping
{
    public static LanguageDto ToLanguageDto(this Language language)
    {
        return new LanguageDto(language.Id, language.Name);
    }
}
