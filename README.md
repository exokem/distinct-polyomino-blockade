# Distinct Polyomino Blockade

Shield: [![CC BY-NC-SA 4.0][cc-by-nc-sa-shield]][cc-by-nc-sa]

## License

This work is licensed under a
[Creative Commons Attribution-NonCommercial-ShareAlike 4.0 International License][cc-by-nc-sa].

[![CC BY-NC-SA 4.0][cc-by-nc-sa-image]][cc-by-nc-sa]

[cc-by-nc-sa]: http://creativecommons.org/licenses/by-nc-sa/4.0/
[cc-by-nc-sa-image]: https://licensebuttons.net/l/by-nc-sa/4.0/88x31.png
[cc-by-nc-sa-shield]: https://img.shields.io/badge/License-CC%20BY--NC--SA%204.0-lightgrey.svg


## Block
- bool[][] -> true = part of shape
- id/name

- function: (xyposition, transform) -> occupied positions relative to xyposition with transform applied
  01
  11
  (3,3) -> (3,4); (4,4); (4,3)


## BlockStatus enum
- Available
- Used
- Unusable


## Player
- color rgb (readonly)
- name (readonly)
- blocks: map<block -> BlockStatus>

- BlockStatus indexer `[block]`
    get -> status, set status


## Grid
- 2d color array
- null empty

- bool SetColor(position, color)
- GetColor(position) indexer


## Game
- blockset - list of blocks available to players during game
- players: map<player -> bool> (player & can move still)
- grid
- currentPlayer

- bool CanPlayerMove(playername)
- bool PlaceBlock(position, player, block)
- bool IsGameOver()


let players move their pieces around in the dock while they wait


```mermaid
classDiagram
    class Shape {
        + Name: string
        - _relativeCoordinates: List[Vec2]

        + MapPlacementAt(pos: Vec2, transform: ITransform) IEnumerable[Vec2]
    }

    class Palette {
        + Name: string
        + MainColor: Color
        + Equals()
    }

    class Player {
        + Palette: Palette
        + Name: string

        - _shapes: Dictionary[Shape, ShapeStatus]

    }

    class Grid {
        - _grid: Palette[][]

        + this[position: Vec2i]: Palette
    }

    class Game {
        + ShapeSet: Set[Shape]
        + Players: Dictionary[Player, bool]
        - _grid: Grid
        - _currentPlayer: Player

        + CanPlayerMove(name: string) bool
        + PlaceShape(position: Vec2, player: Player, shape: Shape, transform: ITransform) bool
        + IsGameOver() bool
    }

    class ITransform {
        << interface >>

        + Apply(point: Vec2, width: int, height: int) Vec2
    }


    class ShapeView {
        - _shape: List[Vec2]
        - _transforms: List[ITransform]
    }

    class DrawerView {
        - _shapes: Dictionary[Vec2, ShapeView]
    }

    class IDrawerController {
        << interface >>

        + Shapes: List[List[Vec2]]

    }

    DrawerView ..> ShapeView : uses
    DrawerView ..> IDrawerController : uses

    Game ..> IDrawerController : implements

    Game ..> Grid : uses
    Game ..> Player : uses
    Player ..> Shape : uses 
    Game ..> Shape : uses
    Player ..> Palette : uses
    Grid ..> Palette : uses
    Shape ..> ITransform : uses
```