using TextHandlerLibrary.Interfaces;
using TextHandlerLibrary.Structs;

namespace TextHandlerLibrary.Interfaces
{
    interface IPunctuation: ISentenceItem
    {
        Symbol Value { get; } 
    }
}
