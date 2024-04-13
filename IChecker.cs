public interface IChecker
{
    void Accumulate(int i, string s);
    void Clear();
    bool Xwin();
    bool Owin();
    bool Tie();
}