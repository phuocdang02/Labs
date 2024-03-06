# NOTES

- Angular.json

```json
"optimization": {
  "scripts": true,
  "styles": {
    "minify": true,
    "inlineCritical": false
  },
  "fonts": true
}
```

- Fast folder creation

```bash
mkdir src/app/components
mkdir src/app/services
mkdir src/app/models
mkdir src/app/views
mkdir assets
mkdir environments
```

If your application has complex views or pages, organize them in this folder.
Each view can have its own components, services, and models.
