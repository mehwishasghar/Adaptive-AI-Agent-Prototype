---

## Results

The measurements were analysed using Python. The following summary
statistics were obtained from the three experimental configurations.

| Complexity | Mean FPS | Min FPS | Max FPS | Mean CPU (ms) | Max CPU (ms) | Mean Memory (MB) | Decisions | Target Reached (s) |
|---|---:|---:|---:|---:|---:|---:|---:|---:|
| Low | 733.17 | 321.89 | 801.78 | 1.41 | 2.42 | 1097.41 | 5 | 3.0 |
| Medium | 653.99 | 342.75 | 809.18 | 1.62 | 3.32 | 1097.34 | 12 | 3.0 |
| High | 724.22 | 328.95 | 791.60 | 1.42 | 4.84 | 1098.62 | 14 | 3.0 |

### Observations

- **Decision frequency increased** with AI complexity, from 5 decisions
  in the Low configuration to 12 in Medium and 14 in High.
- **Target-reaching time remained approximately 3 seconds** across all
  configurations.
- **Medium complexity produced the lowest mean FPS** and higher average
  CPU time than Low and High.
- **High complexity produced the highest maximum CPU time**, indicating
  occasional computational spikes.
- **Memory usage remained relatively stable** across the three
  configurations.
- The results suggest that increasing decision complexity does not
  necessarily produce a linear decrease in runtime performance under
  this experimental setup.

These results provide an initial indication of the trade-off between
AI decision frequency, computational cost, and behavioural performance.

---

## Analysis

The experiment demonstrates that increasing the frequency of AI
decision-making changes the computational profile of the agent.

The number of decisions increased substantially between the Low and High
configurations, while target-reaching performance remained unchanged at
approximately 3 seconds.

However, the performance measurements do not show a simple linear
relationship between complexity and FPS. This indicates that other
runtime factors may also influence performance.

A larger number of trials, more complex environments, additional agents,
and controlled hardware conditions would be required to draw stronger
conclusions.

---

## Limitations

This prototype is an initial experimental investigation rather than a
large-scale benchmark.

Important limitations include:

- A single Unity environment was used.
- The experiment used one primary navigation task.
- Each configuration was evaluated under a limited number of runs.
- Hardware and background system load can affect FPS, CPU, and memory
  measurements.
- Behavioural quality was represented primarily by target-reaching
  success/time.
- The current experiment does not evaluate more complex multi-agent
  behaviour.

Future experiments could address these limitations by increasing the
number of trials, introducing multiple agents and environments, and
using more detailed behavioural metrics.

---

## Python Analysis

Python was used to process the Unity-generated CSV measurements and
produce summary statistics and comparison visualisations.

The analysis generates:

- Summary statistics CSV
- Combined results CSV
- FPS comparison graph
- CPU comparison graph
- Memory comparison graph
- Decision-frequency comparison graph
- Target-reaching comparison graph

The generated analysis files are located in:

```text
analysis/
