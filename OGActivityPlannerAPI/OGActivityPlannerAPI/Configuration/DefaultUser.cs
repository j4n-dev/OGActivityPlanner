namespace OGActivityPlannerAPI.Configuration
{
    /// <summary> Represents the configuration for the default user. </summary>
    public class DefaultUser
    {
        public string? UserName { get; set; }

        public string? DisplayName { get; set; }

        public DateOnly? DateOfBirth { get; set; }

        public Guid? AccessCode { get; set; }
    }
}
