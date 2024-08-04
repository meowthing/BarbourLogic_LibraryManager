# Barbour Logic Library Manager
- Multi-menu console interface
- Assumptions
    - UX flow assumptions were made based on how to gather the necessary data to narrow down to relevant operations (e.g. need User ID to do anything user related)
    - 7 day lending period
    - User can have multiple loans
    
- Future additions/improvements
    - Non-book items (disk media, physical objects, etc)
    - Search
    - Front-end
    - Messaging concerns(i.e. console writeline) all handled by the ConsoleDashboard - at the moment I've strewn writelines all over LibManager, implicitly tying it to Console only usage
    - Fail-first checkpoints - allows easier error message handling (multiple reasons why an operation could fail - which is it?)