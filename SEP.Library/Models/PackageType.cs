namespace SEP.Library.Models;

public enum PackageType
{
    Unknown = 0,

    // Passive
    Chip,
    MELF,

    // Diodes
    SOD323,
    SOD523,
    SOD123,
    SMA,
    SMB,
    SMC,

    // Transistors
    SOT23,
    SOT223,
    SOT89,
    SOT143,
    SOT363,

    // IC
    SOIC,
    SOP,
    SSOP,
    TSSOP,
    TSOP,
    QFP,
    LQFP,
    TQFP,
    QFN,
    DFN,
    BGA,

    // Connectors
    Header,
    USB,
    RJ,
    Terminal,

    // Other
    Crystal,
    Oscillator,
    Relay,
    Switch,
    Fuse,
    Other
}