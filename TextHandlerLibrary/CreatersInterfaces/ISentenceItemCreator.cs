using TextHandlerLibrary.SenstenseItemsInterfaces;

namespace TextHandlerLibrary.CreatersInterfaces
{
    public interface ISentenceItemCreator
    {
        ISentenceItem Create(string chars);
    }
}
