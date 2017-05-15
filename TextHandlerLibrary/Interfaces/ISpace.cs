using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.Interfaces
{
    interface ISpace: ISentenceItem
    {
        Symbol Value { get; }
    }
}
