Quando("digito uma cidade e aperto em buscar ubs") do
    visit '/getUbsProxima'
    fill_in(id: 'inputCidade', with: 'Aracaju')
    find('input[value="Buscar UBS"]').click
end

Entao("verifico se uma lista de ubs na cidade foi exibida") do
    find('#table-ubs')
end