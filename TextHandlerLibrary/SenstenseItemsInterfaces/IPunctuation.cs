using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.SenstenseItemsInterfaces
{
    interface IPunctuation: ISentenceItem
    {
        Symbol Value { get; } 
    }
}
