[System.Flags]
public enum CellState{
    Forward = 1, Back = 1 << 1, Left = 1 << 2, Right = 1 << 3, 
    Trap = 1 << 4, Breakable = 1 << 5
}

public static class CellStateExtensionMethods{
    public static bool Is(this CellState s, CellState mask) => (s & mask) != 0;
    public static bool IsNot(this CellState s, CellState mask) => (s & mask) == 0;
    public static CellState With(this CellState s, CellState mask) => s | mask;
    public static CellState Without(this CellState s, CellState mask) => s & ~mask;
}