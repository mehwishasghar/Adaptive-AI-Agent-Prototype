import pandas as pd
import matplotlib.pyplot as plt
from pathlib import Path

# --------------------------------------------------
# Paths
# --------------------------------------------------

RESULTS_DIR = Path("Results")
OUTPUT_DIR = RESULTS_DIR / "Analysis"

OUTPUT_DIR.mkdir(exist_ok=True)

# --------------------------------------------------
# Load experimental data
# --------------------------------------------------

files = {
    "Low": RESULTS_DIR / "low.csv",
    "Medium": RESULTS_DIR / "medium.csv",
    "High": RESULTS_DIR / "high.csv"
}

data = {}

for level, file in files.items():
    df = pd.read_csv(file)
    data[level] = df

# --------------------------------------------------
# Calculate summary statistics
# --------------------------------------------------

summary = []

for level, df in data.items():

    target_rows = df[df["TargetReached"] == True]

    first_target_time = (
        target_rows["Time"].iloc[0]
        if not target_rows.empty
        else None
    )

    summary.append({
        "Complexity": level,
        "Mean FPS": df["FPS"].mean(),
        "Min FPS": df["FPS"].min(),
        "Max FPS": df["FPS"].max(),
        "Mean CPU_ms": df["CPU_ms"].mean(),
        "Max CPU_ms": df["CPU_ms"].max(),
        "Mean Memory_MB": df["Memory_MB"].mean(),
        "Final Decisions": df["Decisions"].iloc[-1],
        "First Target Reached_s": first_target_time
    })

summary_df = pd.DataFrame(summary)

# Save summary
summary_df.to_csv(
    OUTPUT_DIR / "summary.csv",
    index=False
)

# --------------------------------------------------
# Print summary
# --------------------------------------------------

print("\n=== ADAPTIVE AI EXPERIMENT SUMMARY ===\n")

print(
    summary_df.to_string(
        index=False,
        float_format=lambda x: f"{x:.2f}"
    )
)

# --------------------------------------------------
# Graph 1: Mean FPS
# --------------------------------------------------

plt.figure(figsize=(8, 5))

plt.bar(
    summary_df["Complexity"],
    summary_df["Mean FPS"]
)

plt.title("Average FPS by AI Complexity")
plt.xlabel("AI Complexity")
plt.ylabel("Mean FPS")

plt.tight_layout()

plt.savefig(
    OUTPUT_DIR / "mean_fps.png",
    dpi=200
)

plt.close()

# --------------------------------------------------
# Graph 2: Mean CPU time
# --------------------------------------------------

plt.figure(figsize=(8, 5))

plt.bar(
    summary_df["Complexity"],
    summary_df["Mean CPU_ms"]
)

plt.title("Average CPU Time by AI Complexity")
plt.xlabel("AI Complexity")
plt.ylabel("CPU Time (ms)")

plt.tight_layout()

plt.savefig(
    OUTPUT_DIR / "mean_cpu.png",
    dpi=200
)

plt.close()

# --------------------------------------------------
# Graph 3: Memory
# --------------------------------------------------

plt.figure(figsize=(8, 5))

plt.bar(
    summary_df["Complexity"],
    summary_df["Mean Memory_MB"]
)

plt.title("Average Memory Usage by AI Complexity")
plt.xlabel("AI Complexity")
plt.ylabel("Memory (MB)")

plt.tight_layout()

plt.savefig(
    OUTPUT_DIR / "mean_memory.png",
    dpi=200
)

plt.close()

# --------------------------------------------------
# Graph 4: Decision count
# --------------------------------------------------

plt.figure(figsize=(8, 5))

plt.bar(
    summary_df["Complexity"],
    summary_df["Final Decisions"]
)

plt.title("AI Decision Count by Complexity")
plt.xlabel("AI Complexity")
plt.ylabel("Number of Decisions")

plt.tight_layout()

plt.savefig(
    OUTPUT_DIR / "decision_count.png",
    dpi=200
)

plt.close()

# --------------------------------------------------
# Graph 5: Target reaching time
# --------------------------------------------------

plt.figure(figsize=(8, 5))

plt.bar(
    summary_df["Complexity"],
    summary_df["First Target Reached_s"]
)

plt.title("Time to Reach Target")
plt.xlabel("AI Complexity")
plt.ylabel("Time (seconds)")

plt.tight_layout()

plt.savefig(
    OUTPUT_DIR / "target_reach_time.png",
    dpi=200
)

plt.close()

print("\nAnalysis complete.")
print(f"Files saved to: {OUTPUT_DIR}")
