namespace HelperDates
{
    public static class DateHelper
    {
        public static DateTime TransformDates(string fecha)
        {
            return DateTime.Parse(fecha);
        }
    }
}