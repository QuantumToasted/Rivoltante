namespace Rivoltante.Bonfire;

public interface IApiModelUpdatable<in TModel>
    where TModel : IncomingEventApiModel
{
    void Update(TModel model);
}