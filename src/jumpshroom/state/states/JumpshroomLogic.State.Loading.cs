namespace GameDemo;

using Chickensoft.LogicBlocks;

public partial class JumpshroomLogic : LogicBlock<JumpshroomLogic.IState> {
  public partial record State {
    public record Loading : State, IGet<Input.Launch> {
      public IPushEnabled Target { get; }

      public Loading(IPushEnabled target) {
        Target = target;

        this.OnEnter(() => {
          Get<IGameRepo>().OnJumpshroomUsed();
          Output(new Output.Animate());
        });
      }

      // Springy top is fully compressed, so it is ready to launch.
      public IState On(in Input.Launch input) => new Launching(Target);
    }
  }
}
