Quando("digito uma latitude e uma longitude negativas") do
    visit '/buscar-ubs-by-lat-long.html'
    fill_in(id: 'inputLatitude', with: '-23.228155')
    fill_in(id: 'inputLongitude', with: '-45.918946')
    find('input[value="Buscar UBS mais proxima"]').click
end

Entao("verifico se a ubs mais proxima foi localizada e exibida corretamente") do
    find('#table-ubs')
    texto = find('')
    expect(texto.text).to eql 'São José dos Campos'
end