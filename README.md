# Exam Ref 70-483 Examples
Examples from the Programming in C# Microsoft Exam Ref 70-483 Book written by Wouter de Kort.

## Chapter 1. Manage program flow

### Objective 1.1. Implement multithreading and asynchronous processing

#### A. Understanding Threads
- LISTING 1-1 Creating a thread with the Thread class
- LISTING 1-2 Using a background thread
- LISTING 1-3 Using the ParameterizedThreadStart
- LISTING 1-4 Stopping a thread
- LISTING 1-5 Using the ThreadStaticAttribute
- LISTING 1-6 Using ThreadLocal
- LISTING 1-7 Queuing some work to the thread pool

#### B. Using Tasks
- LISTING 1-8 Starting a new Task
- LISTING 1-9 Using a Task that returns a value
- LISTING 1-10 Adding a continuation
- LISTING 1-11 Scheduling different continuation tasks
- LISTING 1-12 Attaching child tasks to a parent task
- LISTING 1-13 Using a TaskFactory
- LISTING 1-14 Using Task.WaitAll
- LISTING 1-15 Using Task.WaitAny

#### C. Using the Parallel class
- LISTING 1-16 Using Parallel.For and Parallel.ForEach
- LISTING 1-17 Using Parallel.Break

#### D. Using Async and Await
- LISTING 1-18 Async and Await
- LISTING 1-19 Scalability versus responsiveness
- LISTING 1-20 Using ConfigureAwait
- LISTING 1-21 Continuing on a thread pool instead of the UI thread

#### E. Using Parallel Language Integrated Query (PLINQ)
- LISTING 1-22 Using AsParallel
- LISTING 1-23 Unordered parallel query