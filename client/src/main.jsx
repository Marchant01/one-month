import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import { BrowserRouter, Routes, Route } from 'react-router'
import Dashboard from './dashboard'
import Todo from './todo'
// import './index.css'

function HomePage() {
  return <main>
    <div id='main-page-container'>
      <div className='navbar-container'>
        <Dashboard/>
      </div>
    </div>
  </main>
}

createRoot(document.getElementById('root')).render(
  <StrictMode>
    <BrowserRouter>
      <Routes>
        <Route index element={ <HomePage/> } />
        <Route path="/todo" element={ <Todo/> } />
      </Routes>
    </BrowserRouter>
  </StrictMode>,
)