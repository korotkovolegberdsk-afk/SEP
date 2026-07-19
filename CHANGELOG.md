\# SEP - SMT Engineering Platform



\---



\# Version 2.0.0



\## Status



In Development



\---



\## Added



\- YGX Import

\- Package Manager

\- Package Resolver

\- Component Viewer



\---



\## Fixed



\- Restored YGX Import architecture

\- Fixed Viewer <-> Import interaction

\- Fixed YGX parser

\- Fixed Import Window



\---



\## Architecture



Projects



\- SEP.Core

\- SEP.Database

\- SEP.Import

\- SEP.Library

\- SEP.Viewer



Rules



\- Import project does not access Library directly.

\- Viewer coordinates Import and Library.

\- One package = one completed feature.

\- Build must succeed before Git commit.



\---



\## Build



Status: OK



\---



\## Git



Next Commit:



SEP 2.0.0 - Architecture Cleanup

