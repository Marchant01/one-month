import { useNavigate } from 'react-router'

export default function Dashboard () {
  const navigate = useNavigate()

  return <div>
    <nav>
      <button onClick={ () => navigate('/')}>Home</button>
      <button onClick={ () => navigate('/todo')}>Todo</button>
    </nav>
  </div>
}