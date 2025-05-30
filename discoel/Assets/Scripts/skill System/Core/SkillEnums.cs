namespace SkillSystem
{
    public enum AttributeType
    {
        Intellect,
        Psyche,
        Physique,
        Motorics
    }

    public enum SkillType
    {
        // Intellect
        Logic, Encyclopedia, Rhetoric, Drama, Conceptualization, VisualCalculus,
        // Psyche  
        Empathy, InlandEmpire, Authority, Suggestion, EspritDeCorps, Volition,
        // Physique
        Endurance, PainThreshold, PhysicalInstrument, Electrochemistry, Shivers, HalfLight,
        // Motorics
        Perception, ReactionSpeed, HandEyeCoordination, Interfacing, Composure, SavoirFaire
    }

    public enum SkillCheckResult
    {
        Success,
        Failure,
        CriticalSuccess,
        CriticalFailure
    }
}