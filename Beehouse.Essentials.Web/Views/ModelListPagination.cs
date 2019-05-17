namespace __Blazor.Beehouse.Essentials.Web.Views
{
    /// <summary>
    /// Pagination settings
    /// </summary>
    public class ModelListPagination
    {
        /// <summary>
        /// Current page of the list
        /// </summary>
        public int Page { get; set; } = 1;

        /// <summary>
        /// Limit of list items in each page
        /// </summary>
        public int Limit { get; set; } = 10;

        /// <summary>
        /// Count of total number of items in list
        /// </summary>
        public int Count { get; set; } = 0;
    }
}
