namespace Ecs.Components.Events
{
  public struct GameStateChangedEvent
  {
    public GameState State;
  }

  public enum GameState
  {
    Play,
    Dead,
    Win
  }
}