# Adaptive AI Agent Prototype

A small experimental prototype investigating how different levels of AI
decision complexity affect runtime performance and behavioural outcomes
in a Unity environment.

The project combines a Unity-based AI experiment with Python-based
analysis of the collected performance measurements.

---

## Research Question

How does increasing AI decision complexity affect computational
performance and behavioural outcomes in a real-time Unity environment?

The experiment compares three AI complexity levels:

- Low
- Medium
- High

The objective is to examine the trade-off between more frequent AI
decision-making and runtime efficiency.

---

## Experiment Overview

The Unity environment contains an AI agent that navigates toward a target
using different levels of decision-making complexity.

Each configuration was executed under the same experimental setup and
measured over approximately 30 seconds.

The experiment records:

- FPS
- CPU time per frame
- Memory usage
- Number of AI decisions
- Target-reaching behaviour

The collected measurements are exported as CSV files and analysed using
Python.

---

## Experimental Conditions

| Configuration | Description |
|---|---|
| Low | Lower AI decision complexity |
| Medium | Intermediate AI decision complexity |
| High | Higher AI decision complexity |

The complexity levels primarily differ in how frequently the agent
evaluates and updates its behaviour.

---

## Measurements

### 1. FPS

Measures the rendering performance of the Unity environment.

Higher FPS generally indicates lower rendering/runtime workload.

### 2. CPU Time

Measured in milliseconds and used as an indicator of computational cost.

### 3. Memory Usage

Measures the memory footprint observed during the experiment.

### 4. Decision Frequency

Records the number of AI decisions made by the agent during the run.

This provides a direct indication of how frequently the AI evaluates
its behaviour.

### 5. Behavioural Outcome

The experiment records whether the agent successfully reaches its target.

This allows computational performance to be considered alongside
behavioural outcome.

---

## Experimental Procedure

For each AI complexity level:

1. The Unity experiment was started.
2. The agent was given the same target-oriented task.
3. Runtime performance was recorded.
4. AI decisions were counted.
5. Target-reaching behaviour was recorded.
6. Measurements were exported to CSV.
7. The resulting dataset was analysed using Python.

The three resulting datasets are:

```text
low.csv
medium.csv
high.csv
