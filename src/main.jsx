import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router'

function App() {
  return (
    <BrowserRouter>
    </BrowserRouter>
  )
}

createRoot(document.getElementById('root')).render(
  <StrictMode>

  </StrictMode>,
)
