using Microsoft.VisualStudio.TestTools.UnitTesting;


[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items and dequeue them one by one, ensuring that 
    // the item with the highest priority is dequeued first.
    // Expected Result: "Item3", "Item2", "Item1" (in order of priority)
    // Defect(s) Found: 
    public void TestPriorityQueue_Dequeue_HighestPriorityFirst()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 3);

        Assert.AreEqual("Item3", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same priority and ensure that 
    // the first item enqueued is dequeued first (FIFO).
    // Expected Result: "Item1", "Item2" (FIFO order for same priority)
    // Defect(s) Found: 
    public void TestPriorityQueue_Dequeue_FifoForSamePriority()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 2);
        priorityQueue.Enqueue("Item2", 2);

        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Try to dequeue from an empty queue, expecting an exception.
    // Expected Result: InvalidOperationException with message "The queue is empty."
    // Defect(s) Found: 
    public void TestPriorityQueue_Dequeue_EmptyQueue()
    {
        var priorityQueue = new PriorityQueue();

        try
        {
            priorityQueue.Dequeue();
            Assert.Fail("Exception should have been thrown.");
        }
        catch (InvalidOperationException e)
        {
            Assert.AreEqual("The queue is empty.", e.Message);
        }
    }

    [TestMethod]
    // Scenario: Enqueue multiple items, where one item has a higher priority than others,
    // and ensure that the highest priority item is dequeued first.
    // Expected Result: "Item4", "Item2", "Item1", "Item3"
    // Defect(s) Found: 
    public void TestPriorityQueue_Dequeue_HighestPriorityFirst_WithMultipleItems()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Item1", 1);
        priorityQueue.Enqueue("Item2", 2);
        priorityQueue.Enqueue("Item3", 1);
        priorityQueue.Enqueue("Item4", 3);

        Assert.AreEqual("Item4", priorityQueue.Dequeue());
        Assert.AreEqual("Item2", priorityQueue.Dequeue());
        Assert.AreEqual("Item1", priorityQueue.Dequeue());
        Assert.AreEqual("Item3", priorityQueue.Dequeue());
    }
}
