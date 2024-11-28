# Groot

Scheduler for DA/DS projects under Ma Namespace

## Hangfire Dashboard
* URL
    ```
    {host}/jobs/recurring
    ```
* Release
    * if a job is removed/rename in code and released, the old job will still appear in dashboard since the scheduler list is loaded from Redis
    * you need to manually delete removed/renamed old job in dashboard
    * try always keep A/B cluster scheduler code the same
