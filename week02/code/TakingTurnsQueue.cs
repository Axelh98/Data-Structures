public class TakingTurnsQueue
{
    private readonly Queue<Person> _people = new();

    public int Length => _people.Count;

    /// <summary>
    /// Add new people to the queue with a name and number of turns
    /// </summary>
    /// <param name="name">Name of the person</param>
    /// <param name="turns">Number of turns remaining</param>
    public void AddPerson(string name, int turns)
    {
        var person = new Person(name, turns);
        _people.Enqueue(person);
    }

    public Person GetNextPerson()
    {
        if (_people.Count == 0)
        {
            throw new InvalidOperationException("No one in the queue.");
        }

        // Remove first person from the queue
        Person person = _people.Dequeue();

        // If the person has turns > 0, decrease their turns by 1
        if (person.Turns > 0)
        {
            person.Turns -= 1;  // Decrease turns only if turns > 0
        }

        // Re-enqueue the person if they still have turns > 0 or if they have infinite turns (turns <= 0)
        if (person.Turns > 0 || person.Turns == -1)  // Ensure that people with <= 0 turns stay forever
        {
            _people.Enqueue(person);  // Re-add the person to the queue to maintain the circular behavior
        }

        return person;
    }
}

// THIS IS SOOO HARD ! ! ! ! !
// THIS IS SOOO HARD ! ! ! ! !
// THIS IS SOOO HARD ! ! ! ! !