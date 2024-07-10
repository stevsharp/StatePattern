using System.Reactive;
using System.Reactive.Subjects;

namespace BlazorBookking.Services;

public class SubmitService
{

    private readonly Subject<Unit> _submitSubject = new();

    public IObservable<Unit> SubmitRequested => _submitSubject;

    public void RequestSubmit()
    {
        _submitSubject.OnNext(Unit.Default);
    }

}
