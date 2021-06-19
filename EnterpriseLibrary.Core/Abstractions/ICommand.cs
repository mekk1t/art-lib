namespace KitProjects.EnterpriseLibrary.Core.Abstractions
{
    public interface ICommand
    {
        void Execute();
    }

    public interface ICommand<in TCommandArgs>
    {
        void Execute(TCommandArgs args);
    }

    public interface ICommand<in TCommandArgs, out TResult>
    {
        TResult Execute(TCommandArgs args);
    }
}
