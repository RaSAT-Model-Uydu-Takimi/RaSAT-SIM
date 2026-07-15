# Workspace Rules for RaSAT SIM & FlyingAnalysis

## Pre-Approval Rule (Önce Anla ve Anlat, Onay Alınca İşe Koyul)
Whenever the user requests a new feature, panel, layout change, or implementation:
1. **DO NOT start coding or making backend/UI modifications immediately.**
2. **First, explain clearly what you understood** from the user's request and describe/show **how the design/implementation will look and work** (using wireframes, mockups, structure descriptions, or step-by-step explanations).
3. **Wait for explicit user approval** (e.g., "Onaylıyorum", "İşe koyul", "Devam et") before writing code or building the actual backend/UI controls.

## Modular Designer Architecture Rule
- Never put all UI controls into a single large Form (`Form1.Designer.cs`).
- Always use separate `UserControl` panels with their own separate `.Designer.cs` files to prevent context bloat (`context degradation`).
