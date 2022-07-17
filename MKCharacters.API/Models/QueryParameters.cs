namespace MKCharacters.API.Models;
public class QueryParameters
{
    public int _maxSize = 100;
    private int _size = 50;

    public int Page { get; set; } = 1;
    public int Size
    {
        get => _size;
        set
        {
            _size = Math.Min(_maxSize, value);
        }
    }

    public string SortBy { get; set; } = "Id";

    private string _sortOrder = "asc";
    public string SortOrder
    {
        get => _sortOrder;
        set
        {
            if (value == "asc" || value == "desc")
            {
                _sortOrder = value;
            }
        }
    }
}
