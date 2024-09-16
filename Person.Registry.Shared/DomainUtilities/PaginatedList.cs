namespace Person.Registry.Shared.DomainUtilities
{
    public class PaginatedList<T>
    {
        public PaginatedList() { }

        public PaginatedList(IList<T> data, int pageNumber, int pageSize)
        {
            PageSize = pageSize;
            PageNumber = pageNumber;
            TotalPages = (int)Math.Ceiling((double)data.Count() / PageSize);
            Data = data.Skip((PageNumber - 1) * PageSize).Take(pageSize).ToList();
        }

        public IList<T> Data { get; private set; }
        public int PageNumber { get; private set; }
        public int PageSize { get; private set; }
        public int TotalPages { get; private set; }
    }
}
