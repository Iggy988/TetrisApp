using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris.Blocks;
public abstract class Block
{
    protected abstract Position[][] Tiles { get; } //tile positions in 4 rotations
    protected abstract Position StartOffset { get; } // decide where block spawns in grid
    public abstract int Id { get; } //destingish block

    private int rotationState;
    private Position offset;

    public Block()
    {
        offset = new Position(StartOffset.Row, StartOffset.Column);
    }

    //method loops over tile position in tile rotation state and add row and column offset
    public IEnumerable<Position> TilePositions()
    {
        foreach (Position p in Tiles[rotationState])
        {
            yield return new Position(p.Row + offset.Row, p.Column + offset.Column);
        }
    }

    //rotata block 90 clockwise
    public void RotateCW()
    {
        rotationState = (rotationState + 1) % Tiles.Length;
    }

    //rotata block 90 counterclockwise
    public void RotateCCW()
    {
        if (rotationState == 0)
        {
            rotationState = Tiles.Length - 1;
        }
        else
        {
            rotationState--;
        }
    }

    //move block by given number of rows and columns
    public void Move(int rows, int columns)
    {
        offset.Row += rows;
        offset.Column += columns;
    }

    //reset rotatioin and position
    public void Reset()
    {
        rotationState = 0;
        offset.Row = StartOffset.Row;
        offset.Column = StartOffset.Column;
    }
}
