# Delayed Bootstrap alert

```html
@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<div class="container">
    <div class="alert alert-primary alert-dismissible fade show d-none"
         role="alert"
         id="customAlert">

        <strong>Attention</strong> time to take a break.
        <button type="button" class="btn-close" 
                data-bs-dismiss="alert" 
                aria-label="Close"></button>

    </div>
</div>

@section Scripts
{
    <script>
        document.addEventListener("DOMContentLoaded", handleClick);

        async function handleClick() {
            await new Promise((resolve) => setTimeout(resolve, 3000));
            document.querySelector("#customAlert").classList.remove("d-none");
        }
    </script>
}

```
