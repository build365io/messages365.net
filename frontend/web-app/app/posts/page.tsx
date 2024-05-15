import React from 'react'
import Listings from './Listings'

export default function page() {

  return (
    <div className='grid grid-cols-4 gap-3'>
      <div className='col-span-3 mx-auto'>
        <Listings />
      </div>       
  
      <div>
        <div className='col-span-1 sticky top-36'>
            <div>Bacon ipsum dolor amet turducken beef ribs leberkas, shoulder shank buffalo filet mignon ball tip tenderloin andouille biltong t-bone. Tongue rump fatback turkey, boudin pork loin corned beef chicken prosciutto. Meatball turducken shankle jowl, cupim tail andouille strip steak. Biltong venison andouille, hamburger fatback kielbasa ribeye cupim bresaola. Kevin short loin turducken, beef ribs ball tip meatloaf swine bresaola leberkas chislic chuck turkey. Swine cupim spare ribs, rump biltong kielbasa tri-tip tongue short ribs venison turducken leberkas sirloin chislic ham. Ham hock pork chop leberkas boudin cupim bresaola porchetta turducken pancetta picanha salami tail pig meatloaf corned beef.

Salami sausage shank ham cupim pork loin. Tri-tip andouille ball tip fatback tenderloin turducken kevin. Fatback turkey corned beef kevin landjaeger sirloin chuck t-bone kielbasa beef ribs boudin ham hock. Tri-tip strip steak biltong turducken, pancetta meatball buffalo prosciutto chislic pork loin salami andouille swine corned beef. Frankfurter turkey jerky biltong brisket shankle boudin capicola chislic bresaola meatloaf. Kielbasa tongue tenderloin pastrami spare ribs, frankfurter doner shoulder tail porchetta pork chop biltong ribeye. Pig pork belly strip steak salami corned beef sirloin.

Does your lorem ipsum text long for something a little meatier? Give our generator a try… it’s tasty!</div>
        </div>
      </div>
    </div>
  )
}
