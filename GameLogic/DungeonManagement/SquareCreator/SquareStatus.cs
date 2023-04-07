namespace GameLogic.DungeonManagement.SquareCreator
{
    public enum SquareStatus
    {
        Empty = ' ',
        Floor = '.',
        WallHorizontal = '═',
        WallVertical = '║',
        CornerNW = '╔',
        CornerSE = '╝',
        CornerNE = '╗',
        CornerSW = '╚',
        Door = '╬',
        Hallway = '█',
        Stairway = '≣',
        Player = '☺',
        Item = '$',
        Enemy = 'E',
        Ally = 'W'
    }
}