namespace TextHandlerLibrary.Interfaces
{
    public interface ITextItemCreator
    {
        ISentence Create();
        void Add(ISentenceItem sentenceItem);
        void Clear();
    }
}
