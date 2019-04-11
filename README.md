# Performance.Analysis
Project to benchmark C# and share its result

Dictionary iterations

|                                Method |  Job | Runtime |       Mean |     Error |    StdDev |
|-------------------------------------- |----- |-------- |-----------:|----------:|----------:|
|             DictionaryWithForeachLoop |  Clr |     Clr |   502.8 us |  3.277 us |  3.066 us |
|          DictionaryWithForEachKeyLoop |  Clr |     Clr | 1,429.7 us |  7.166 us |  6.703 us |
|       DictionaryWithWhileOnEnumerator |  Clr |     Clr |   541.3 us | 15.487 us | 13.728 us |
| DictionaryWithDoWhileLoopOnEnumerator |  Clr |     Clr |   537.5 us |  4.397 us |  4.113 us |
|             DictionaryWithForeachLoop | Core |    Core |   434.7 us |  1.154 us |  1.080 us |
|          DictionaryWithForEachKeyLoop | Core |    Core | 1,176.5 us |  9.355 us |  8.293 us |
|       DictionaryWithWhileOnEnumerator | Core |    Core |   468.3 us |  2.711 us |  2.536 us |
| DictionaryWithDoWhileLoopOnEnumerator | Core |    Core |   466.7 us |  1.593 us |  1.490 us |

List iterations

|                      Method |  Job | Runtime |      Mean |     Error |    StdDev |
|---------------------------- |----- |-------- |----------:|----------:|----------:|
|         ListWithForeachLoop |  Clr |     Clr | 382.30 us | 4.4354 us | 3.9319 us |
|             ListWithForLoop |  Clr |     Clr |  98.98 us | 0.5601 us | 0.5239 us |
|           ListWithWhileLoop |  Clr |     Clr |  98.80 us | 0.7529 us | 0.6287 us |
|         ListWithDoWhileLoop |  Clr |     Clr |  98.77 us | 0.5485 us | 0.4580 us |
|         ListWithLinqForeach |  Clr |     Clr | 231.29 us | 0.8282 us | 0.7747 us |
|   ListWithWhileOnEnumerator |  Clr |     Clr | 382.44 us | 2.3136 us | 1.9320 us |
| ListWithDoWhileOnEnumerator |  Clr |     Clr | 380.77 us | 1.5868 us | 1.2389 us |
|         ListWithForeachLoop | Core |    Core | 395.57 us | 1.8393 us | 1.7205 us |
|             ListWithForLoop | Core |    Core |  98.82 us | 0.4806 us | 0.4013 us |
|           ListWithWhileLoop | Core |    Core |  98.65 us | 0.4883 us | 0.4329 us |
|         ListWithDoWhileLoop | Core |    Core |  66.14 us | 0.4707 us | 0.4172 us |
|         ListWithLinqForeach | Core |    Core | 198.28 us | 1.1916 us | 0.9950 us |
|   ListWithWhileOnEnumerator | Core |    Core | 397.17 us | 3.4412 us | 2.8736 us |
| ListWithDoWhileOnEnumerator | Core |    Core | 395.95 us | 1.5256 us | 1.3524 us |
