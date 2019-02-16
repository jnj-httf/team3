Quando("digito uma latitude e uma longitude") do
    visit 'https://latitudelongitude.org/br/sao-jose-dos-campos/'
    fill_in(id: 'latitude', with: '-23.17944')
    fill_in(id: 'longitude', with: '-45.88694')
    find('input[value="Buscar UBS mais proxima"]').click
end

Entao("verifico se a ubs mais proxima foi localizada e exibida") do
    find('#tabela_ubs')
end