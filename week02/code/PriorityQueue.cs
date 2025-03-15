public class PriorityQueue
{
    private List<PriorityItem> _queue = new();

    /// <summary>
    /// Add a new value to the queue with an associated priority.  The
    /// node is always added to the back of the queue regardless of 
    /// the priority.
    /// </summary>
    /// <param name="value">The value</param>
    /// <param name="priority">The priority</param>
    public void Enqueue(string value, int priority)
    {
        var newNode = new PriorityItem(value, priority);
        _queue.Add(newNode);
    }

    public string Dequeue()
    {
        if (_queue.Count == 0) // Verificar si la cola está vacía
        {
            throw new InvalidOperationException("The queue is empty.");
        }

        // Encuentra el índice del ítem con la prioridad más alta a eliminar
        // find the index of the item with the highest priority to remove
        // IF there are multiple items with the same priority, FIFO is used
        // HERE IS THE SOLUTION
        var highPriorityIndex = 0;
        for (int index = 1; index < _queue.Count; index++)
        {
            // Si se encuentra una prioridad más alta, actualizar el índice
            if (_queue[index].Priority > _queue[highPriorityIndex].Priority)
            {
                highPriorityIndex = index;
            }
            // Si las prioridades son iguales, se sigue la regla FIFO
            else if (_queue[index].Priority == _queue[highPriorityIndex].Priority && index < highPriorityIndex)
            {
                highPriorityIndex = index;
            }
        }

        // Guardar el valor de la cola de prioridad que tiene la más alta prioridad
        var value = _queue[highPriorityIndex].Value;

        // Eliminar el elemento de la cola
        _queue.RemoveAt(highPriorityIndex);

        // Devolver el valor del elemento eliminado
        return value;
    }


    public override string ToString()
    {
        return $"[{string.Join(", ", _queue)}]";
    }
}

internal class PriorityItem
{
    internal string Value { get; set; }
    internal int Priority { get; set; }

    internal PriorityItem(string value, int priority)
    {
        Value = value;
        Priority = priority;
    }

    public override string ToString()
    {
        return $"{Value} (Pri:{Priority})";
    }
}