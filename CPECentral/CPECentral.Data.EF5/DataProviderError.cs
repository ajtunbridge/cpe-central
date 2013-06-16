namespace CPECentral.Data.EF5
{
    public enum DataProviderError
    {
        ConnectionTimedOut,
        ConnectionFailed,
        RelationshipViolation,
        UniqueConstraintViolation,
        InvalidData,
        Unknown
    }
}