using Microsoft.VisualStudio.TestTools.UnitTesting;

// TODO Problem 2 - Write and run test cases and fix the code to match requirements.

[TestClass]
public class PriorityQueueTests
{
    [TestMethod]
    // Scenario: Enqueue multiple items with different priorities and dequeue them.
    //           Items: "Low" (Pri: 2), "High" (Pri: 5), "Medium" (Pri: 3).
    // Expected Result: "High", then "Medium", then "Low".
    // Defect(s) Found: 
    // - The loop condition in Dequeue (`index < _queue.Count - 1`) uses an off-by-one boundary. 
    //   It fails to examine the very last item in the list.
    // - The item is never actually removed from the underlying `_queue` list, causing duplicate reads 
    //   of the same item if Dequeue is called consecutively.
    public void TestPriorityQueue_1()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("Low", 2);
        priorityQueue.Enqueue("High", 5);
        priorityQueue.Enqueue("Medium", 3);

        Assert.AreEqual("High", priorityQueue.Dequeue());
        Assert.AreEqual("Medium", priorityQueue.Dequeue());
        Assert.AreEqual("Low", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Enqueue multiple items with the same highest priority to test FIFO behavior.
    //           Items: "First High" (Pri: 5), "Second High" (Pri: 5), "Low" (Pri: 1).
    // Expected Result: "First High" should be removed first because it is closest to the front.
    // Defect(s) Found: 
    // - The comparison operator used is `>=` (`if (_queue[index].Priority >= _queue[highPriorityIndex].Priority)`). 
    //   This updates the index to the later item when priorities are equal, violating the FIFO requirement 
    //   by picking the item closest to the back instead of the front.
    public void TestPriorityQueue_2()
    {
        var priorityQueue = new PriorityQueue();
        priorityQueue.Enqueue("First High", 5);
        priorityQueue.Enqueue("Second High", 5);
        priorityQueue.Enqueue("Low", 1);

        Assert.AreEqual("First High", priorityQueue.Dequeue());
        Assert.AreEqual("Second High", priorityQueue.Dequeue());
    }

    [TestMethod]
    // Scenario: Attempt to Dequeue from an empty priority queue.
    // Expected Result: An InvalidOperationException should be thrown with the message "The queue is empty."
    // Defect(s) Found: 
    // - None. The guard clause handles empty queues correctly.
    public void TestPriorityQueue_Empty()
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
}