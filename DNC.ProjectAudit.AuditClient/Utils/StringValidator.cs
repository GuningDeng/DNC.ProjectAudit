namespace DNC.ProjectAudit.AuditClient.Utils
{
    public class StringValidator
    {
        public static bool IsInvalidStringByNullOrEmptyOrWhiteSpaceAndLength(string input, int starting, int ending)
        {
            // Check if the string is null or empty
            if (string.IsNullOrEmpty(input))
            {
                return true;
            }

            // Check if the string contains only whitespace
            if (string.IsNullOrWhiteSpace(input))
            {
                return true;
            }

            // Check if the string has less than 8 characters
            if (input.Length < starting)
            {
                return true;
            }

            // Check if the string has more than 512 characters
            if (input.Length > ending)
            {
                return true;
            }

            // If none of the conditions are met, the string is valid
            return false;
        }
    }
}
