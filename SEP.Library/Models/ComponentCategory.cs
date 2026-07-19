namespace SEP.Library.Models;

public enum ComponentCategory
{
    Unknown = 0,

    // Passive
    Resistor,
    Capacitor,
    Inductor,
    Ferrite,
    Fuse,

    // Semiconductor
    Diode,
    Led,
    Transistor,
    IC,

    // Electromechanical
    Connector,
    Relay,
    Switch,

    // Timing
    Crystal,
    Oscillator,

    // Mechanical
    Screw,
    Spacer,
    Shield,

    Other
}