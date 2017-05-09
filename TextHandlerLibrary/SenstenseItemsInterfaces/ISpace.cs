using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    interface ISpace: ISentenceItem
    {
        Symbol Value { get; }
    }
}
