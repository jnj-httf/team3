Quando("digito uma latitude e uma longitude") do
    visit '/buscar-ubs-by-lat-long.html'
    fill_in(id: 'inputLatitude', with: '-23.17944')
    fill_in(id: 'inputLongitude', with: '-45.88694')
    find('input[value="Buscar UBS Proxima"]').click
end

Entao("verifico se a ubs mais proxima foi localizada e exibida") do
    find('#table-ubs')
end