import { useEffect, useState } from 'react'

export default function Todo() {
  const [Errand,setErrand] = useState([])
  return <main>
    <h1>Todo:</h1>
    <ShowErrands/>
  </main>


  function ShowErrands() {
      useEffect(() => {
        fetch('api/errands')
          .then((res) => res.json())
          .then((data) => setErrand(data))
      }, [])
    }

    // if !data
    // return message
    // return <ul> element

    if(!data) {
      return <ul>
        <ul>
          
        </ul>
      </ul>
    }
}
